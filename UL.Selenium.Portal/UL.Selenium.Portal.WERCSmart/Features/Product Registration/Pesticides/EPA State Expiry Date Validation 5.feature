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
@Ingredients
@ignore
@run_EPAState5

Feature:  EPA State Expiry Date Validation 5 (Suite ID: 56545)


# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56640
Scenario: [56640] Pesticide Data - EPA Expiration date validation (Alabama - only the year is checked - no more than 2 years out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55876 (EPA expiration date - enter next year - any date) for state: AL
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55877 (EPA expiration date - enter current year plus 2 - any date) for state: AL
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55878 (EPA expiration date - enter current year plus 3 - any date) for state: AL
	Then in page Pesticide Details - State Registration page I should see error: State AL: Valid date is only on the year (no set Month/Day), no more than two (2) calendar years out.
	And I call Shared Step 55875 (EPA expiration date - enter current year - any date today or greater) for state: AL
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56640

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56641
Scenario: [56641] Pesticide Data - EPA Expiration date validation (New York - only the year is checked - no more than 2 years out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55876 (EPA expiration date - enter next year - any date) for state: NY
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55877 (EPA expiration date - enter current year plus 2 - any date) for state: NY
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55878 (EPA expiration date - enter current year plus 3 - any date) for state: NY
	Then in page Pesticide Details - State Registration page I should see error: State NY: Valid date is only on the year (no set Month/Day), no more than two (2) calendar years out.
	And I call Shared Step 55875 (EPA expiration date - enter current year - any date today or greater) for state: NY
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56641

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56642
Scenario: [56642] Pesticide Data - EPA Expiration date validation (Washington - only the year is checked - no more than 2 years out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55876 (EPA expiration date - enter next year - any date) for state: WA
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55877 (EPA expiration date - enter current year plus 2 - any date) for state: WA
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55878 (EPA expiration date - enter current year plus 3 - any date) for state: WA
	Then in page Pesticide Details - State Registration page I should see error: State WA: Valid date is only on the year (no set Month/Day), no more than two (2) calendar years out.
	And I call Shared Step 55875 (EPA expiration date - enter current year - any date today or greater) for state: WA
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56642

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56644
Scenario: [56644] Pesticide Data - EPA Expiration date validation (Washington - only the year is checked - no more than 2 years out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55876 (EPA expiration date - enter next year - any date) for state: PR
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55877 (EPA expiration date - enter current year plus 2 - any date) for state: PR
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I call Shared Step 55878 (EPA expiration date - enter current year plus 3 - any date) for state: PR
	Then in page Pesticide Details - State Registration page I should see error: State PR: Valid date is only on the year (no set Month/Day), no more than two (2) calendar years out.
	And I call Shared Step 55875 (EPA expiration date - enter current year - any date today or greater) for state: PR
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56644

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56653
Scenario: [56653] Pesticide Data - EPA Expiration date validation (Michigan - June 30th no more than 1 year out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55843 (EPA expiration date - enter current year - Not June 30th) for state: MI
	Then in page Pesticide Details - State Registration page I should see error: State MI: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55844 (EPA expiration date - enter next year - Not June 30th) for state: MI
	Then in page Pesticide Details - State Registration page I should see error: State MI: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55846 (EPA expiration date - enter next year - June 30th) for state: MI
	Then in page Pesticide Details - State Registration page I should see error: State MI: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55845 (EPA expiration date - enter current year - June 30th) for state: MI
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56653

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56654
Scenario: [56654] Pesticide Data - EPA Expiration date validation (Ohio - June 30th no more than 1 year out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55843 (EPA expiration date - enter current year - Not June 30th) for state: OH
	Then in page Pesticide Details - State Registration page I should see error: State OH: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55844 (EPA expiration date - enter next year - Not June 30th) for state: OH
	Then in page Pesticide Details - State Registration page I should see error: State OH: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55846 (EPA expiration date - enter next year - June 30th) for state: OH
	Then in page Pesticide Details - State Registration page I should see error: State OH: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55845 (EPA expiration date - enter current year - June 30th) for state: OH
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56654

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56655
Scenario: [56655] Pesticide Data - EPA Expiration date validation (Tennessee - June 30th no more than 1 year out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55843 (EPA expiration date - enter current year - Not June 30th) for state: TN
	Then in page Pesticide Details - State Registration page I should see error: State TN: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55844 (EPA expiration date - enter next year - Not June 30th) for state: TN
	Then in page Pesticide Details - State Registration page I should see error: State TN: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55846 (EPA expiration date - enter next year - June 30th) for state: TN
	Then in page Pesticide Details - State Registration page I should see error: State TN: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55845 (EPA expiration date - enter current year - June 30th) for state: TN
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56655

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56656
Scenario: [56656] Pesticide Data - EPA Expiration date validation (Tennessee - June 30th no more than 1 year out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I call Shared Step 55843 (EPA expiration date - enter current year - Not June 30th) for state: TN
	Then in page Pesticide Details - State Registration page I should see error: State TN: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55844 (EPA expiration date - enter next year - Not June 30th) for state: TN
	Then in page Pesticide Details - State Registration page I should see error: State TN: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55846 (EPA expiration date - enter next year - June 30th) for state: TN
	Then in page Pesticide Details - State Registration page I should see error: State TN: Valid date is June 30 no more than one calendar year out at any given time.
	And I call Shared Step 55845 (EPA expiration date - enter current year - June 30th) for state: TN
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56656

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56645
Scenario: [56645] Pesticide Data - EPA Expiration date validation (Oklahoma - March 31st, June 30th, Sept 30th or December 31st no more than 1 year out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Chlorine       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	#And I We will be working with Oklahoma (OK) for the next set of steps
	# And I Select a date for the current year that is not March 31st, June 30th, Sept 30th or Dec 31st
	And I enter a registration date for the current year that is not March 31st, June 30th, Sept 30th or Dec 31st for state: OK
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State OK: Valid dates are March 31, June 30, September 30 or December 31 no more than one (1) calendar year out at any given time.
	And I enter a registration date for the next year that is not March 31st, June 30th, Sept 30th or Dec 31st for state: OK
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State OK: Valid dates are March 31, June 30, September 30 or December 31 no more than one (1) calendar year out at any given time.
	And I enter the EPA registration date in the current year:
		| State | Day | Month | Increment year? |
		| OK    | 31  | 3     | yes             |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I enter the EPA registration date in the current year:
		| State | Day | Month | Increment year? |
		| OK    | 30  | 6     | yes             |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I enter the EPA registration date in the current year:
		| State | Day | Month | Increment year? |
		| OK    | 30  | 9     | yes             |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I enter the EPA registration date in the current year:
		| State | Day | Month | Increment year? |
		| OK    | 31  | 12     | yes             |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 1:
		| State | Day | Month |
		| OK    | 31  | 3     |
	And I click continue
	# if current date > March 31 then no error and Transportation Details 1 else error is shown, else
	And If the current date is after (MM/DD): 03/31 then I confirm no error is shown for the State: OK - else I confirm the following error is displayed: State OK: Valid dates are March 31, June 30, September 30 or December 31 no more than one (1) calendar year out at any given time.
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 1:
		| State | Day | Month |
		| OK    | 30  | 6     |
	And I click continue
	# if current date > June 30 then no error and Transportation Details 1 else error is shown, else
	And If the current date is after (MM/DD): 06/30 then I confirm no error is shown for the State: OK - else I confirm the following error is displayed: State OK: Valid dates are March 31, June 30, September 30 or December 31 no more than one (1) calendar year out at any given time.
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 1:
		| State | Day | Month |
		| OK    | 30  | 9     |
	And I click continue
	# if current date > June 30 then no error and Transportation Details 1 else error is shown, else
	And If the current date is after (MM/DD): 09/30 then I confirm no error is shown for the State: OK - else I confirm the following error is displayed: State OK: Valid dates are March 31, June 30, September 30 or December 31 no more than one (1) calendar year out at any given time.
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 1:
		| State | Day | Month |
		| OK    | 31  | 12     |
	And I click continue
	# if current date > June 30 then no error and Transportation Details 1 else error is shown, else
	And If the current date is after (MM/DD): 12/31 then I confirm no error is shown for the State: OK - else I confirm the following error is displayed: State OK: Valid dates are March 31, June 30, September 30 or December 31 no more than one (1) calendar year out at any given time.
	And I click the page heading: Pesticide Details - State Registration Details
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56645

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
#Removed from regression: 2023/06
@ignore
@TestCase:56646
Scenario: [56646] Pesticide Data - EPA Expiration date validation (Texas - March 31st, June 30th, Sept 30th or December 31st no more than 2 year out)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Chlorine       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I add the EPA registration number: TEST-1234
	And I click continue
	And I enter a registration date for the current year that is not March 31st, June 30th, Sept 30th or Dec 31st for state: TX
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State TX: Valid dates are March 31, June 30, September 30 or December 31 no more than two (2) calendar years out at any given time.
	And I enter a registration date for the next year that is not March 31st, June 30th, Sept 30th or Dec 31st for state: TX
	And I click continue
	Then in page Pesticide Details - State Registration page I should see error: State TX: Valid dates are March 31, June 30, September 30 or December 31 no more than two (2) calendar years out at any given time.
	And I enter the EPA registration date in the current year:
		| State | Day | Month | Increment year? |
		| TX    | 31  | 3     | yes             |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I enter the EPA registration date in the current year:
		| State | Day | Month | Increment year? |
		| TX    | 30  | 6     | yes             |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I enter the EPA registration date in the current year:
		| State | Day | Month | Increment year? |
		| TX    | 30  | 9     | yes             |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I enter the EPA registration date in the current year:
		| State | Day | Month | Increment year? |
		| TX    | 31  | 12     | yes             |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 1:
		| State | Day | Month |
		| TX    | 31  | 3     |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 1:
		| State | Day | Month |
		| TX    | 30  | 6     |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 1:
		| State | Day | Month |
		| TX    | 30  | 9     |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 1:
		| State | Day | Month |
		| TX    | 31  | 12     |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 2:
		| State | Day | Month |
		| TX    | 31  | 3     |
	And I click continue
	And If the current date is after (MM/DD): 03/31 then I confirm no error is shown for the State: TX - else I confirm the following error is displayed: State TX: Valid dates are March 31, June 30, September 30 or December 31 no more than two (2) calendar year out at any given time.
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 2:
		| State | Day | Month |
		| TX    | 30  | 6     |
	And I click continue
	And If the current date is after (MM/DD): 06/30 then I confirm no error is shown for the State: OK - else I confirm the following error is displayed: State OK: Valid dates are March 31, June 30, September 30 or December 31 no more than one (1) calendar year out at any given time.
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 2:
		| State | Day | Month |
		| TX    | 30  | 9     |
	And I click continue
	And If the current date is after (MM/DD): 06/30 then I confirm no error is shown for the State: TX - else I confirm the following error is displayed: State TX: Valid dates are March 31, June 30, September 30 or December 31 no more than two (2) calendar year out at any given time.
	And I click the page heading: Pesticide Details - State Registration Details
	And I select EPA expiration date - enter current year plus 1:
		| State | Day | Month |
		| TX    | 31  | 12     |
	And I click continue
	Then in page Pesticide Details - State Registration Details I should see no errors
	Then I should see the Transportation Details 1 Page
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56646
