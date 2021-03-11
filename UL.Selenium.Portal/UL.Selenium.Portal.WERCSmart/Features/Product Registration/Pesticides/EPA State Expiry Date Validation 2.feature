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
@UPC
@SHA
@run_EPAState2

Feature:  EPA State Expiry Date Validation 2 (Suite ID: 56545)

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
@ScenarioId:930
Scenario: [56601] Pesticide Data - EPA Expiration date validation (Louisiana - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MD
Then in page Pesticide Details - State Registration page I should see error: State MD: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MD
Then in page Pesticide Details - State Registration page I should see error: State MD: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MD
Then I should see the appropriate response depending on today's date for state: MD
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MD
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56601

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
@ScenarioId:931
Scenario: [56602] Pesticide Data - EPA Expiration date validation (Louisiana - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: ME
Then in page Pesticide Details - State Registration page I should see error: State ME: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: ME
Then in page Pesticide Details - State Registration page I should see error: State ME: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: ME
Then I should see the appropriate response depending on today's date for state: ME
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: ME
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56602

# Assigned to Barrett, Beverly
@ScenarioId:932
Scenario: [56603] Pesticide Data - EPA Expiration date validation (Minnesota - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MN
Then in page Pesticide Details - State Registration page I should see error: State MN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MN
Then in page Pesticide Details - State Registration page I should see error: State MN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MN
Then I should see the appropriate response depending on today's date for state: MN
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MN
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56603

# Assigned to Barrett, Beverly
@ScenarioId:933
Scenario: [56604] Pesticide Data - EPA Expiration date validation (Missouri -Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MO
Then in page Pesticide Details - State Registration page I should see error: State MO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MO
Then in page Pesticide Details - State Registration page I should see error: State MO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MO
Then I should see the appropriate response depending on today's date for state: MO
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MO
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56604

# Assigned to Barrett, Beverly
@ScenarioId:934
Scenario: [56605] Pesticide Data - EPA Expiration date validation (Mississippi - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MS
Then in page Pesticide Details - State Registration page I should see error: State MS: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MS
Then in page Pesticide Details - State Registration page I should see error: State MS: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MS
Then I should see the appropriate response depending on today's date for state: MS
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MS
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56605

# Assigned to Barrett, Beverly
@ScenarioId:935
Scenario: [56606] Pesticide Data - EPA Expiration date validation (Montana - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MT
Then in page Pesticide Details - State Registration page I should see error: State MT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MT
Then in page Pesticide Details - State Registration page I should see error: State MT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MT
Then I should see the appropriate response depending on today's date for state: MT
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MT
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56606

# Assigned to Barrett, Beverly
@ScenarioId:936
Scenario: [56607] Pesticide Data - EPA Expiration date validation (North Carloina - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NC
Then in page Pesticide Details - State Registration page I should see error: State NC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NC
Then in page Pesticide Details - State Registration page I should see error: State NC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NC
Then I should see the appropriate response depending on today's date for state: NC
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NC
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56607

# Assigned to Barrett, Beverly
@ScenarioId:937
Scenario: [56608] Pesticide Data - EPA Expiration date validation (Nebraska - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NC
Then in page Pesticide Details - State Registration page I should see error: State NC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NC
Then in page Pesticide Details - State Registration page I should see error: State NC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NC
Then I should see the appropriate response depending on today's date for state: NC
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NC
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56608

# Assigned to Barrett, Beverly
@ScenarioId:938
Scenario: [56609] Pesticide Data - EPA Expiration date validation (New Hampshire - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NH
Then in page Pesticide Details - State Registration page I should see error: State NH: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NH
Then in page Pesticide Details - State Registration page I should see error: State NH: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NH
Then I should see the appropriate response depending on today's date for state: NH
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NH
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56609

# Assigned to Barrett, Beverly
@ScenarioId:939
Scenario: [56610] Pesticide Data - EPA Expiration date validation (New Jersey - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NJ
Then in page Pesticide Details - State Registration page I should see error: State NJ: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NJ
Then in page Pesticide Details - State Registration page I should see error: State NJ: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NJ
Then I should see the appropriate response depending on today's date for state: NJ
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NJ
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56610

                                                                                                                                                                                    |

@ScenarioId:9325
	Scenario: [56651] Pesticide Data - EPA Expiration date validation (Delaware - July 1st no more than two years out)
    Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62778
	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
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
	Then I enter the following EPA Pesticide Registration No.: Test-1234
	Given I click continue

	And I call Shared Step 136221 (EPA expiration date - enter current year - Not July 1st) for state: DE
    Then in page Pesticide Details - State Registration page I should see error: State DE: Valid date is July 01 no more than two calendar years out at any given time.

	And  I call Shared Step 136222 (EPA expiration date - enter next year - Not July 1st) for state: DE
    Then in page Pesticide Details - State Registration page I should see error: State DE: Valid date is July 01 no more than two calendar years out at any given time.

	And I call Shared Step 136223 (EPA expiration date - enter current year plus 2 - Not July 1st) for state: DE
    Then in page Pesticide Details - State Registration page I should see error: State DE: Valid date is July 01 no more than two calendar years out at any given time.

	And I call Shared Step 136224 (EPA expiration date - enter current year - July 1st) for state: DE
	Then in page Pesticide Details - State Registration Details I should see no errors

	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62778


@tfs_design
#Bug ticket placed for the error that is not displaying - Philip
	@ScenarioId:9324
Scenario: [56652] Pesticide Data - EPA Expiration date validation (Massachusetts - June 30th no more than 1 year out)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62778
	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
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
	Then I enter the following EPA Pesticide Registration No.: Test-1234
	Given I click continue

	And I call Shared Step 55843 (EPA expiration date - enter current year - Not June 30th) for state: MA
    Then in page Pesticide Details - State Registration page I should see error: State MA: Valid date is June 30 no more than one calendar year out at any given time.

	And I call Shared Step 55844 (EPA expiration date - enter next year - Not June 30th) for state: MA
    Then in page Pesticide Details - State Registration page I should see error: State MA: Valid date is June 30 no more than one calendar year out at any given time.

	And I call Shared Step 55846 (EPA expiration date - enter next year - June 30th) for state: MA
    Then in page Pesticide Details - State Registration page I should see error: State MA: Valid date is June 30 no more than one calendar year out at any given time.

	And I call Shared Step 55845 (EPA expiration date - enter current year - June 30th) for state: MA
	Then in page Pesticide Details - State Registration Details I should see no errors

	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62778


@ScenarioId:9334
	Scenario: [56598] Pesticide Data - EPA Expiration date validation (Kansas - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
    Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62778
	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
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
	Then I enter the following EPA Pesticide Registration No.: Test-1234
	Given I click continue

	And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: KS
    Then in page Pesticide Details - State Registration page I should see error: State KS: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.

	And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: KS
    Then in page Pesticide Details - State Registration page I should see error: State KS: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.

	And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: KS
    Then in page Pesticide Details - State Registration page I should see error: State KS: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.

	And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: KS
	Then in page Pesticide Details - State Registration Details I should see no errors

	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62778


@ScenarioId:9393
	Scenario: [26827] UPC Assessment Details
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
	And I confirm the Product UPC window has opened
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
	Then In UPC Retailer and Feed I check that the following sections contain the corresponding titles: 
	| Section Name | Column Names													   | Column Numbers       |
	| DOT          | UN,HazClass,Pkg Group,Ltd Qty,DOT Pkging Code,Exception,Sp Permit | 12,13,14,15,16,17,18 |
	| IMDG         | UN,HazClass,Pkg Group,Ltd Qty									   | 19,20,21,22          |
	| IATA         | UN,HazClass,Pkg Group,Ltd Qty									   | 23,24,25,26          |
	| TDG		   | UN,HazClass,Pkg Group,Ltd Qty									   | 27,28,29,30          |
