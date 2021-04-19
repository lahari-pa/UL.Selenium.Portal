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
@run_Pesticides
@UPC
Feature: Pesticides

@ScenarioId:655
Scenario: [62775] Pesticides - Validation of Which one best describes your product question - Prevents, Destroys etc
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62775
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	And I should see the Additional Product Information Page
	Given I see the following sections
		| Section                               |
		| Which best describes your product, including when FIFRA 25(b) Exempt |
	Given I should see a total of 4 radio buttons for the section: Which best describes your product, including when FIFRA 25(b) Exempt
	Then I should see the following radio buttons:
		| Button                                                                                                                                       |
		| Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)                                           |
		| Claims to sterilize, disinfect, sanitize or otherwise rid of bacteria, viruses or microorganisms that are infectious or pathogenic to humans. |
		| Regulates Plant Growth, Defoliates (removes leaves) Plants and controls growth, Dehydrates plants for control of growth                      |
		| Product is not considered a pesticide product                                                                                                |
	And in the New Product page I click Continue
	Then I should see an error message: This is a required field.
	And I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)
	Then Which best describes your product, including when FIFRA 25(b) Exempt should not be showing the error messages: This is a required field.
	And in the New Product page I click Continue
	Then Which best describes your product, including when FIFRA 25(b) Exempt should not be showing the error messages: This is a required field.
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62775

@ScenarioId:660
Scenario: [62849] Pesticide - Manually entered date not altered by refresh from Kelly
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Given I save the product information as: TestCase62849
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then I should see the Pesticide Details - U.S. Page
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given in the New Product page I click Continue
	Given I add the EPA registration number: 305-48
	Given in the New Product page I click Continue
	Then I should see the Pesticide Details - State Registration Details Page
	Then I confirm that there is data populated in the Expiration Date Column for some States
	Then I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'
	Then I edit the Expiration Date to: 2020-12-01 for the State: NY on the Pesticide State Registration Details page
	Given I confirm the Expiration Date Provided By Kelly field for state: NY is blank
	Given in the Pesticide Details - State Registration Details page I click Continue
	Given I click the page heading: Pesticide Details - U.S.
	Then I should see the Pesticide Details - U.S. Page
	Given in the Pesticide Details - U.S. page I click Continue
	Given I confirm the Expiration Date Provided By Kelly field for state: NY is blank
	Then I confirm the Expiration Date field for state: NY is showing the value: 2020-12-01
	Given I click the Update Wercs Smart data with EPA data through Kelly Services link
	Then I confirm the Expiration Date field for state: NY is showing the value: 2020-12-01
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62849

@ScenarioId:661
Scenario: [62852] Pesticide - Product Label is required
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Given I save the product information as: TestCase62852
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57505 (Pesticide Data - U.S. - EPA reg #(No) - EPA Exempt # (Random) - Continue - Happy Path)
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then I should see the Additional Documents to Provide Page
	Given I see the following sections
		| Section                               |
		| Provide Full Product Label (required) |
	Given in the Additional Documents to Provide page I click Continue
	Then Provide Full Product Label (required) should be showing the error messages: Document is required: Please upload a PDF of the product label (full label).
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Please upload a PDF of the product label (full label). and file: C:\Dependencies\WERCSmart\testdoc.pdf
	# Click continue confirm no error
	Given I click continue
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62852

@ScenarioId:644
Scenario: [56547] Pesiticde Data - EPA registration - Active Ingredient information returned from call to Kelly API
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Given I save the product information as: TestCase56547
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then I should see the Pesticide Details - U.S. Page
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given in the New Product page I click Continue
	Given I add the EPA registration number: 73605-2
	Given in the New Product page I click Continue
	Then I should see the Pesticide Details - State Registration Details Page
	Given I click the page heading: Pesticide Details - U.S.
	Then I should see the Pesticide Details - U.S. Page
	Given I confirm data for EPA Registration: 73605-2 is complete
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56547

@ScenarioId:646
Scenario: [57512] Pesticide question shows in Additional Product Information for Flow 2L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Given I save the product information as: TestCase57512
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57512

@ScenarioId:647
Scenario: [57516] Pesticide question shows in Additional Product Information for Flow 2-LS
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fertilizer
	Given I save the product information as: TestCase57516
	Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57516

@ScenarioId:648
Scenario: [57520] Pesticide question shows in Additional Product Information for Flow 2-LS-B
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Animal Deterrent - Non-Aerosol
	Given I save the product information as: TestCase57520
	Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57520

@ScenarioId:649
Scenario: [57522] Pesticide question shows in Additional Product Information for Flow 2-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide
	Given I save the product information as: TestCase57522
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57522

@ScenarioId:650
Scenario: [57527] Pesticide question shows in Additional Product Information for Flow 6-A
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Disinfectant (Aerosol)
	Given I save the product information as: TestCase57527
	Given I call Shared Step 57528 (Product Characteristics - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57527

@ScenarioId:651
Scenario: [57529] Pesticide question shows in Additional Product Information for Flow 6-AG
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Fogger
	Given I save the product information as: TestCase57529
	Given I call Shared Step 57532 (Product Characteristics - Aerosol & Gas available - Select Gas - Continue - Happy Path)
	Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57529

@ScenarioId:652
Scenario: [57533] Pesticide question shows in Additional Product Information for Flow 6-All
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Flea and Tick
	Given I save the product information as: TestCase57533
	Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57533

@ScenarioId:653
Scenario: [57534] Pesticide question shows in Additional Product Information for Flow 6-LS
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bathroom and Tile Cleaner - Non-aerosol
	Given I save the product information as: TestCase57534
	Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57534

@ScenarioId:654
Scenario: [57546] Pesticide question shows in Additional Product Information for Flow 2-A
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Algicide - Aerosol
	Given I save the product information as: TestCase57546
	Given I call Shared Step 57528 (Product Characteristics - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57546

@ScenarioId:662
Scenario: [66344] Pesticide question shows in Additional Product Information for 3-Pest
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wipes, Disinfecting
	Given I save the product information as: TestCase66344
	Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase66344

@ScenarioId:663
Scenario: [66345] Pesticide question shows in Additional Product Information for Flow3-VOCSCA
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wood Finishing Cloth with Stain
	Given I save the product information as: TestCase66345
	Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 56799 (Confirm Additional Product Information shows Pesticide question and its radio buttons)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase66345

@56500
@ScenarioId:641
Scenario: [56500] Pesticide Data- Canada - validation of questions (updated)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
	Given I save the product information as: TestCase56500
	And I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Appreciable                                  |
	Given I call Shared Step 57798 (Additional Product Information- Pesticide, Canada Only - No to everything else, Continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Then I should see the Pesticide Details - Canada Page
	Then Field exists: Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product
	#And I Confirm the Canadian Pest Control Number question shows a data entry type control
	# 'field exists' only passes on a data entry element
	Then in the Pesticide Details - Canada page I click Continue
	# JS TFS test case changed to remove Manitoba, Saskatchewan and Northwest Territory from expected fields with error
	Then For every field in the table I should see the following error: This is a required field.
		| Field                |
		| Provide Canada       |
		| Product              |
		| Alberta              |
		| British Columbia     |
		| Labrador             |
		| New Brunswick        |
		| New Foundland        |
		| Nova Scotia          |
		| Ontario              |
		| Prince Edward Island |
		| Quebec               |
		| Yukon Territory      |

	Then For every field in the table I should not see the following error: This is a required field.
		| Field               |
		| Manitoba            |
		| Saskatchewan        |
		| Northwest Territory |

	# Type in a Canadian Pest Control Products (PCP) Registration Number with more than 5 digits and less than 8 digits
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 279255
	Then in the Pesticide Details - Canada page I click Continue
	Then Provide Canada should be showing the error messages: Enter a valid number (5 or 8 digits).
	# Enter data in the Canada Pest Control Number field that contains alpha characters
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: abc256
	Then in the Pesticide Details - Canada page I click Continue
	Then Provide Canada should be showing the error messages: Enter a valid number (5 or 8 digits).
	# Enter less than 5 digits in the Canada Pest Control Number field
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 2792
	Then in the Pesticide Details - Canada page I click Continue
	Then Provide Canada should be showing the error messages: Enter a valid number (5 or 8 digits).
	# Enter more than 8 digits in the Canada Pest Control Number field
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 2792101055
	Then in the Pesticide Details - Canada page I click Continue
	Then Provide Canada should be showing the error messages: Enter a valid number (5 or 8 digits).
	# Enter in a valid PCP Registration (5 or 8 digits)
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 27925
	Then in the Pesticide Details - Canada page I click Continue
	Then Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product should not be showing any error messages
	Then Field exists: Product's packaging includes a Poison Danger symbol
	And The following options should be displayed for section: Product's packaging includes a Poison Danger symbol
		| Option |
		| Yes    |
		| No     |
	And Section: Product's packaging includes a Poison Danger symbol should be showing an error message
	Given I set the Product's packaging includes a Poison Danger symbol field to: No
	Then Product's packaging includes a Poison Danger symbol should not be showing any error messages
	Given I set the Alberta field to: Choose...
	Then For every field in the table I call Shared Step 56494 expecting error: This is a required field.
		| Field                |
		| Alberta              |
		| British Columbia     |
		| Labrador             |
		| New Brunswick        |
		| New Foundland        |
		| Nova Scotia          |
		| Ontario              |
		| Prince Edward Island |
		| Quebec               |
		| Yukon Territory      |
	# Confirm the Manitoba question shows N/A as already selected
	And Manitoba should be showing the value: N/A
	#Confirm "None" is shown as already selected for the Saskatchewan question
	And Saskatchewan should be showing the value: None
	#Confirm N/A is shown as already selected for the Northwest Territory question
	And Northwest Territory should be showing the value: N/A
	Then in the Pesticide Details - Canada page I click Continue
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 69388 (Retailer - Canada Only - Select No Retailer/No UPC product > Done > Continue - Happy Path)
	Given I call Shared Step 69389 (Regulatory Documents to Provide - Canada only - Confirm questions - Request author, add label and todays date - Continue)
	Then I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	Then I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment 0000
	Then In the Data Acceptance page I select Yes, Agreed
	And I should not see any error messages
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56500

@ScenarioId:643
Scenario: [56541] Pesticide Data - United States - EPA Registered - Data returned from call to Kelly API (done)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with pest control
	Given I save the product information as: TestCase56541
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I should see the Pesticide Details - U.S. Page
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given in the New Product page I click Continue
	Given I add the EPA registration number: 72315-6
	Given in the New Product page I click Continue
	And I should see the Pesticide Details - State Registration Details Page
	Given I confirm that there is data populated in the Expiration Date Column for some States
	Then I confirm that every date in the Expiration Date column has a matching date in the Expiration Date provided by Kelly column
	And I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'
	Given in the New Product page I click Continue
	And I should see the Transportation Details 1 Page
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56541

@ScenarioId:656
Scenario: [62778] Pesticide Details - U.S. - Validation of Product has an Environment Protection Agency (EPA) Registration Number
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62778
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then I should see the Pesticide Details - U.S. Page
	And I see the following sections
		| Section                                                                  |
		| Product has an Environmental Protection Agency (EPA) Registration Number |
	And The following options should be displayed for section: Product has an Environmental Protection Agency (EPA) Registration Number
		| Option |
		| Yes    |
		| No     |
	Given I click continue
	Then Product has an Environmental Protection Agency (EPA) Registration Number should be showing the error messages: This is a required field.
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Then Product has an Environmental Protection Agency (EPA) Registration Number should not be showing the error messages: This is a required field
	And I confirm the EPA Pesticide Registration table is shown
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: No
	Then I confirm the EPA Pesticide Registration table is not shown
	And I see the following sections
		| Section                         |
		| Select the applicable exemption |
	Then Product has an Environmental Protection Agency (EPA) Registration Number should not be showing the error messages: This is a required field
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62778

@ScenarioId:657
Scenario: [62780] Pesticide Details - U.S. - Validation of EPA Registration Number table
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62780
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then I should see the Pesticide Details - U.S. Page
	And I see the following sections
		| Section                                                                  |
		| Product has an Environmental Protection Agency (EPA) Registration Number |
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I confirm the EPA Pesticide Registration table is shown
	Then I confirm the EPA Registration table contains the heading: Provide the EPA Registration Number
	And I confirm the following columns are displayed in the EPA Registration table
		| Column Heading                 |
		| EPA Pesticide Registration No. |
		| Federal EPA Active Ingredient. |
		| Percent of Active Ingredient.  |
		| Remove                         |
	Given I click continue
	Then I should see an error message: Federal Registration Number is required
	Given I click Remove for the item on the first EPA Registration Table row
	And I confirm the EPA Registration Table contains a total of 0 rows
	And I click continue
	Then I should see an error message: Required answer missing
	Given I click Add Row in the EPA Registration Table
	And I click continue
	Then I should see an error message: Federal Registration Number is required
	And I confirm the EPA Registration Table contains a total of 1 rows
	Given I add the EPA registration number: 123456789
	Given I click continue
	Then I should see the Pesticide Details - State Registration Details Page
	And I check the State Pesticide Registration Number field matches the text: 123456789
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62780

@ScenarioId:645
Scenario: [56577] Pesticide Data - EPA data - Is Kelly Data is updated when user edits date from Kelly
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase56577
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then I should see the Pesticide Details - U.S. Page
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given I add the EPA registration number: 56228-10
	Given I click continue
	Then I should see the Pesticide Details - State Registration Details Page
	And I confirm that there is data populated in the Expiration Date Column for some States
	And I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'
	Then I edit the Expiration Date to: 2020-12-31 for the State: AZ on the Pesticide State Registration Details page
	Given in the New Product page I click Continue
	And I should see the Transportation Details 1 Page
	Then I click the page heading: Pesticide Details - State Registration Details
	Then I confirm the 'Is Kelly Data' field for State: AZ is not checked
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56577

@ScenarioId:658
Scenario: [62799] Pesticide Details - State Registration - Manual entry of dates and coloring
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62799
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then I should see the Pesticide Details - U.S. Page
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given I add the EPA registration number: testregistrationnumber
	Given I click continue
	Then I should see the Pesticide Details - State Registration Details Page
	And I confirm the State Registration EPA table does not contain any Expiration data
	Given I set the Expiration Date to be 29 days from today using the calendar selector for state: AL
	Then I confirm that the EPA table row for state: AL is highlighted with the color: orange
	And I confirm the Expiration Date Provided By Kelly field for state: AL is blank
	And I confirm the 'Is Kelly Data' field for State: AL is not checked
	Given I set the Expiration Date to be 60 days from today using the calendar selector for state: NY
	Then I confirm that the EPA table row for state: NY is highlighted with the color: yellow
	Given I set the Expiration Date to be 100 days from today using the calendar selector for state: WA
	Then I confirm that the EPA table row for state: WA is highlighted with the color: none
	Given I click continue
	And I should see the Transportation Details 1 Page
	Then I click the page heading: Pesticide Details - State Registration Details
	Then I confirm that the EPA table row for state: AL is highlighted with the color: orange
	Then I confirm that the EPA table row for state: NY is highlighted with the color: yellow
	Then I confirm that the EPA table row for state: WA is highlighted with the color: none
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62799

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides
@ScenarioId:642
Scenario: [56502] Pesticide Data - United States - EPA Exempt
	Given I generate a random UPC number and save as: UPC56502
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then I should see the Pesticide Details - U.S. Page
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: No
	Given I see the following sections
		| Section                         |
		| Select the applicable exemption |
	And The following radio buttons should be displayed for section: Select the applicable exemption
		| Button                                               |
| Product is FIFRA 25(b) Exempt.                       |
		| Food Based Pesticides - Exempt from EPA Registration |
		| Device based products - Exempt from EPA Registration |
		| Pheromone Traps – Exempt from EPA Registration       |
	And I click continue
	Then Select the applicable exemption should be showing the error messages: This is a required field.
	And I set the Select the applicable exemption option to: Food Based Pesticides - Exempt from EPA Registration
	Then Select the applicable exemption should not be showing the error messages: This is a required field.
	And I click continue
	And I should see the Transportation Details 1 Page
	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then I should see the Additional Documents to Provide Page
	And I click continue
	Then Provide Full Product Label (required) should be showing the error messages: Document is required: Please upload a PDF of the product label (full label).
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Please upload a PDF of the product label (full label). and file: C:\Dependencies\WERCSmart\testdoc.pdf
	Given I click continue
	Then I should see the Optional Reports and Documents Available for Purchase Page
	And I click continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment 0000
And I call Shared Step 73956 (Go to Summary and verify data) with product type: Pet Shampoo with Pest Control
	Then In the Data Acceptance page I select Yes, Agreed
	And In the Data Acceptance page I click on the Accept button
	Given If purchase details are showing click confirm order
	#And I Confirm the Purchase summary step is shown, depending on your subscription you will see either the success message or the product details and the Confirm order button.  If the product is shown click Confirm order
	And I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	#And I Use the shared step below to search for your product - you may have to wait a few minutes for the product to show in submitted (the Zuora process)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase56502)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase56502 and its status is: Submitted
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase56502)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase56502)

#And I Go to the State Pesticide Section of MTR/CKLT SECT0127
#And I Confirm the Pesticide data RPDS does not show any data Heading for the RPDS reads "State Pesticide Information Group"
@ScenarioId:664
Scenario: [71051] Pesticide Details - EPA Registration number if edited is NOT refresh from Kelly when the Update WERCSmart data link is used
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase71051
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I should see the Pesticide Details - U.S. Page
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given in the New Product page I click Continue
	Given I add the EPA registration number: 72315-6
	Given in the New Product page I click Continue
	And I should see the Pesticide Details - State Registration Details Page
	Given I update each Registration Number with the appended text '-edited'
	Given in the New Product page I click Continue
	And I should see the Transportation Details 1 Page
	Then I click the page heading: Pesticide Details - State Registration Details
	And I should see the Pesticide Details - State Registration Details Page
	Then I check each State Pesticide Registration Number contains the edited suffix
	Given I click the Update Wercs Smart data with EPA data through Kelly Services link
	Then I check each State Pesticide Registration Number contains the edited suffix
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase71051

@ScenarioId:659
Scenario: [62848] Pesticide Details - EPA Expiration Date is refresh from Kelly when the Update WERCSmart data link is used
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62848
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I should see the Pesticide Details - U.S. Page
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given in the New Product page I click Continue
	Given I add the EPA registration number: 56228-10
	Given in the New Product page I click Continue
	And I should see the Pesticide Details - State Registration Details Page
	Given I confirm that there is data populated in the Expiration Date Column for some States
	And I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'
	Then I edit the Expiration Date to: 2020-12-31 for the State: AZ on the Pesticide State Registration Details page
	Given in the New Product page I click Continue
	Then I click the page heading: Pesticide Details - U.S.
	And I should see the Pesticide Details - U.S. Page
	Given in the New Product page I click Continue
	And I should see the Pesticide Details - State Registration Details Page
	Then I confirm the 'Is Kelly Data' field for State: AZ is not checked
	Given I click the Update Wercs Smart data with EPA data through Kelly Services link
	Then I confirm the Expiration Date matches the value provided by Kelly on the State Registration Details Page for the edited State
	Then I confirm the 'Is Kelly Data' field for State: AZ is checked
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62848


@ScenarioId:10534
Scenario:[121120] Pesticide - New Radio Icon Option
    Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC121120
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with pest control
	Then I save the product information as: TestCase121120
	And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 105379 Additional Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I should see the Transportation Details 1 Page
    And The following options should be displayed exclusively for section: Product is Regulated for Transport
    | Option                               |
    | Yes                                  |
    | No, due to an exemption or exception |
    | Not Regulated                        |
    And I set the Product is Regulated for Transport field to: Not Regulated
    And I click continue
	And In the 'Select Retailers' window I select the retailer: Walgreens
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC121120, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order

	
@ScenarioId:9323
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
#Given I call Shared Step 135134 (Additional Product Information - YES to pesticide - Canada only, No OSHA, No Direct Ship, - Continue - Happy Path)
Given I call Shared Step 140562 (Additional Product Information - YES to pesticide - Canada only, No OSHA, No Direct Ship, No CA Cleaning - Continue - Happy Path)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 74-98-6   | Propane       | 100     | false               |            | false       |
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Then I should see the Pesticide Details - Canada Page
Then I check the options in the dropdown menus for the following sections
| Section                    | Options                                                                                                                                                                                                                       |
| Alberta                    | None,Schedule 1,Schedule 2,Schedule 3,Schedule 4                                                                                                                                                                              |
| British Columbia           | None,Permit Restricted,Restricted,Commercial,Domestic,Excluded                                                                                                                                                                |
| Manitoba                   | None,Commercial,Controlled Purchase,Not Regulated,Restricted,Self-Select                                                                                                                                                      |
| New Brunswick              | None,Banned,Domestic / Self-Select,Non-Domestic                                                                                                                                                                               |
| New Foundland and Labrador | None,Banned,Domestic,Commerical,Restricted                                                                                                                                                                                    |
| Nova Scotia                | None,Allowed / Self-Select,Banned,Commercial,Controlled Purchase,Restricted,Not Regulated                                                                                                                                     |
| Ontario                    | None,Class A: Manufacturing Products,Class B: Restricted,Class C: Commercial,Class D: Domestic with License,Class D: Domestic without License,Class D: Domestic Controlled Purchase Requiring a License,Class E: Treated Seed |
| Prince Edward Island       | Banned,Controlled Purchase,Exempt: Schedule 2,Exempt: Schedule 7,Non-Domestic,None,Self-Select: Schedule 8                                                                                                                    |
| Quebec                     | None,Class 1,Class 2,Class 3,Class 3A,Class 4,Class 5,Banned                                                                                                                                                                  |
| Saskatchewan               | None,Commercial,Restricted                                                                                                                                                                                                    |
| Northwest Territory        | Not Applicable                                                                                                                                                                                                                |
| Yukon Territory            | None,Commercial,Domestic,Restricted,Use Permit                                                                                                                                                                                |       
