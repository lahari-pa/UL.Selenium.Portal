@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@ProductGrid
@DataSummarySheet
@wercsmart
@NewProduct
@RetailPartners
@run_EPAState

Feature:  EPA State Expiry Date Validation (Suite ID: 56545)


@TestCase:56593
Scenario: [56593] Pesticide Data - EPA Expiration date validation (Iowa - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wipes, Disinfecting
Given I save the product information as: TestCase56593
Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 81468 (Physical and Chemical Properties - Solid only available - without secondary physical state)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: IA
Then in page Pesticide Details - State Registration page I should see error: State IA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: IA
Then in page Pesticide Details - State Registration page I should see error: State IA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: IA
Then I should see the appropriate response depending on today's date for state: IA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: IA
Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56593

@TestCase:56592
Scenario: [56592] Pesticide Data - EPA Expiration date validation (Georgia - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wood Finishing Cloth with Stain
Given I save the product information as: TestCase56592
Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: GA
Then in page Pesticide Details - State Registration page I should see error: State GA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: GA
Then in page Pesticide Details - State Registration page I should see error: State GA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: GA
Then I should see the appropriate response depending on today's date for state: GA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: GA
Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56592

@TestCase:56582
Scenario: [56582] Pesticide Data - EPA Expiration date validation (Alaska - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wood Finishing Cloth with Stain
Given I save the product information as: TestCase56582
Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: AK
Then in page Pesticide Details - State Registration page I should see error: State AK: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: AK
Then in page Pesticide Details - State Registration page I should see error: State AK: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: AK
Then I should see the appropriate response depending on today's date for state: AK
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: AK
#Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56582

@TestCase:56591
Scenario: [56591] Pesticide Data - EPA Expiration date validation (Colorado Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Flying Bug Insecticide - Non-aerosol
Given I save the product information as: TestCase56591
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: CO
Then in page Pesticide Details - State Registration page I should see error: State CO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: CO
Then in page Pesticide Details - State Registration page I should see error: State CO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: CO
Then I should see the appropriate response depending on today's date for state: CO
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: CO
Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56591

@TestCase:56590
Scenario: [56590] Pesticide Data - EPA Expiration date validation (California - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Crawling Bug - Aerosol
Given I save the product information as: TestCase56590
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Butane
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: CA
Then in page Pesticide Details - State Registration page I should see error: State CA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: CA
Then in page Pesticide Details - State Registration page I should see error: State CA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: CA
Then I should see the appropriate response depending on today's date for state: CA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: CA
Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56590

@TestCase:56583
Scenario: [56583] Pesticide Data - EPA Expiration date validation (Arkansas > Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
Given I save the product information as: TestCase56583
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: AR
Then in page Pesticide Details - State Registration page I should see error: State AR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: AR
Then in page Pesticide Details - State Registration page I should see error: State AR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: AR
Then I should see the appropriate response depending on today's date for state: AR
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: AR
Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56583

# Assigned to Barrett, Beverly
@TestCase:56594
Scenario: [56594] Pesticide Data - EPA Expiration date validation (Idaho - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
#And [Shared Step 31050 - Welcome page - Save and Next]
#And I In the shared step below use Bathroom and tile cleaner - non-aerosol as your product type
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bathroom and tile cleaner - non-aerosol
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: ID
Then in page Pesticide Details - State Registration page I should see error: State ID: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: ID
Then in page Pesticide Details - State Registration page I should see error: State ID: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: ID
Then I should see the appropriate response depending on today's date for state: ID
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: ID
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56594

# Assigned to Barrett, Beverly
@TestCase:56596
Scenario: [56596] Pesticide Data - EPA Expiration date validation (Indiana - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: IN
Then in page Pesticide Details - State Registration page I should see error: State IN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: IN
Then in page Pesticide Details - State Registration page I should see error: State IN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: IN
Then I should see the appropriate response depending on today's date for state: IN
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: IN
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56596

# Assigned to Barrett, Beverly
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
@TestCase:56599
Scenario: [56599] Pesticide Data - EPA Expiration date validation (Kentucky - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: KY
Then in page Pesticide Details - State Registration page I should see error: State KY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: KY
Then in page Pesticide Details - State Registration page I should see error: State KY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: KY
Then I should see the appropriate response depending on today's date for state: KY
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: KY
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56599


# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
@TestCase:56600
Scenario: [56600] Pesticide Data - EPA Expiration date validation (Louisiana - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: LA
Then in page Pesticide Details - State Registration page I should see error: State LA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: LA
Then in page Pesticide Details - State Registration page I should see error: State LA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: LA
Then I should see the appropriate response depending on today's date for state: LA
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: LA
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56600
