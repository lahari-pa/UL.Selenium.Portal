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
Given I call Shared Step 225948 (EPA expiration date - enter current year - enter next year - check for error) for state:
| State |
| AK    |
Then I should see the Transportation Details 1 Page
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

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: AK
Then in page Pesticide Details - State Registration page I should see error: State AK: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: AK
Then in page Pesticide Details - State Registration page I should see error: State AK: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: AK
Then I should see the appropriate response depending on today's date for state: AK
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: AK

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: AL
Then in page Pesticide Details - State Registration page I should see error: State AL: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: AL
Then in page Pesticide Details - State Registration page I should see error: State AL: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: AL
Then I should see the appropriate response depending on today's date for state: AL
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: AL

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: AR
Then in page Pesticide Details - State Registration page I should see error: State AR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: AR
Then in page Pesticide Details - State Registration page I should see error: State AR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: AR
Then I should see the appropriate response depending on today's date for state: AR
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: AR

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: AZ
Then in page Pesticide Details - State Registration page I should see error: State AZ: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: AZ
Then in page Pesticide Details - State Registration page I should see error: State AZ: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: AZ
Then I should see the appropriate response depending on today's date for state: AZ
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: AZ

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: CA
Then in page Pesticide Details - State Registration page I should see error: State CA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: CA
Then in page Pesticide Details - State Registration page I should see error: State CA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: CA
Then I should see the appropriate response depending on today's date for state: CA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: CA

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: CO
Then in page Pesticide Details - State Registration page I should see error: State CO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: CO
Then in page Pesticide Details - State Registration page I should see error: State CO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: CO
Then I should see the appropriate response depending on today's date for state: CO
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: CO

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: CT
Then in page Pesticide Details - State Registration page I should see error: State CT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: CT
Then in page Pesticide Details - State Registration page I should see error: State CT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: CT
Then I should see the appropriate response depending on today's date for state: CT
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: CT

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: DC
Then in page Pesticide Details - State Registration page I should see error: State DC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: DC
Then in page Pesticide Details - State Registration page I should see error: State DC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: DC
Then I should see the appropriate response depending on today's date for state: DC
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: DC

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: DE
Then in page Pesticide Details - State Registration page I should see error: State DE: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: DE
Then in page Pesticide Details - State Registration page I should see error: State DE: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: DE
Then I should see the appropriate response depending on today's date for state: DE
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: DE

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: FL
Then in page Pesticide Details - State Registration page I should see error: State FL: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: FL
Then in page Pesticide Details - State Registration page I should see error: State FL: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: FL
Then I should see the appropriate response depending on today's date for state: FL
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: FL

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: GA
Then in page Pesticide Details - State Registration page I should see error: State GA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: GA
Then in page Pesticide Details - State Registration page I should see error: State GA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: GA
Then I should see the appropriate response depending on today's date for state: GA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: GA

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: HI
Then in page Pesticide Details - State Registration page I should see error: State HI: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: HI
Then in page Pesticide Details - State Registration page I should see error: State HI: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: HI
Then I should see the appropriate response depending on today's date for state: HI
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: HI

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: IA
Then in page Pesticide Details - State Registration page I should see error: State IA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: IA
Then in page Pesticide Details - State Registration page I should see error: State IA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: IA
Then I should see the appropriate response depending on today's date for state: IA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: IA

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: ID
Then in page Pesticide Details - State Registration page I should see error: State ID: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: ID
Then in page Pesticide Details - State Registration page I should see error: State ID: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: ID
Then I should see the appropriate response depending on today's date for state: ID
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: ID

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: IL
Then in page Pesticide Details - State Registration page I should see error: State IL: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: IL
Then in page Pesticide Details - State Registration page I should see error: State IL: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: IL
Then I should see the appropriate response depending on today's date for state: IL
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: IL

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: IN
Then in page Pesticide Details - State Registration page I should see error: State IN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: IN
Then in page Pesticide Details - State Registration page I should see error: State IN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: IN
Then I should see the appropriate response depending on today's date for state: IN
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: IN

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: KS
Then in page Pesticide Details - State Registration page I should see error: State KS: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: KS
Then in page Pesticide Details - State Registration page I should see error: State KS: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: KS
Then I should see the appropriate response depending on today's date for state: KS
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: KS

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: KY
Then in page Pesticide Details - State Registration page I should see error: State KY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: KY
Then in page Pesticide Details - State Registration page I should see error: State KY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: KY
Then I should see the appropriate response depending on today's date for state: KY
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: KY

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: LA
Then in page Pesticide Details - State Registration page I should see error: State LA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: LA
Then in page Pesticide Details - State Registration page I should see error: State LA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: LA
Then I should see the appropriate response depending on today's date for state: LA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: LA

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MA
Then in page Pesticide Details - State Registration page I should see error: State MA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MA
Then in page Pesticide Details - State Registration page I should see error: State MA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MA
Then I should see the appropriate response depending on today's date for state: MA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MA

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MD
Then in page Pesticide Details - State Registration page I should see error: State MD: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MD
Then in page Pesticide Details - State Registration page I should see error: State MD: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MD
Then I should see the appropriate response depending on today's date for state: MD
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MD

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: ME
Then in page Pesticide Details - State Registration page I should see error: State ME: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: ME
Then in page Pesticide Details - State Registration page I should see error: State ME: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: ME
Then I should see the appropriate response depending on today's date for state: ME
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: ME

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MI
Then in page Pesticide Details - State Registration page I should see error: State MI: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MI
Then in page Pesticide Details - State Registration page I should see error: State MI: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MI
Then I should see the appropriate response depending on today's date for state: MI
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MI

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MN
Then in page Pesticide Details - State Registration page I should see error: State MN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MN
Then in page Pesticide Details - State Registration page I should see error: State MN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MN
Then I should see the appropriate response depending on today's date for state: MN
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MN

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MO
Then in page Pesticide Details - State Registration page I should see error: State MO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MO
Then in page Pesticide Details - State Registration page I should see error: State MO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MO
Then I should see the appropriate response depending on today's date for state: MO
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MO

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MS
Then in page Pesticide Details - State Registration page I should see error: State MS: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MS
Then in page Pesticide Details - State Registration page I should see error: State MS: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MS
Then I should see the appropriate response depending on today's date for state: MS
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MS

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MT
Then in page Pesticide Details - State Registration page I should see error: State MT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MT
Then in page Pesticide Details - State Registration page I should see error: State MT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MT
Then I should see the appropriate response depending on today's date for state: MT
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MT

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NC
Then in page Pesticide Details - State Registration page I should see error: State NC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NC
Then in page Pesticide Details - State Registration page I should see error: State NC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NC
Then I should see the appropriate response depending on today's date for state: NC
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NC

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: ND
Then in page Pesticide Details - State Registration page I should see error: State ND: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: ND
Then in page Pesticide Details - State Registration page I should see error: State ND: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: ND
Then I should see the appropriate response depending on today's date for state: ND
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: ND

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NE
Then in page Pesticide Details - State Registration page I should see error: State NE: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NE
Then in page Pesticide Details - State Registration page I should see error: State NE: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NE
Then I should see the appropriate response depending on today's date for state: NE
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NE

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NH
Then in page Pesticide Details - State Registration page I should see error: State NH: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NH
Then in page Pesticide Details - State Registration page I should see error: State NH: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NH
Then I should see the appropriate response depending on today's date for state: NH
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NH

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NJ
Then in page Pesticide Details - State Registration page I should see error: State NJ: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NJ
Then in page Pesticide Details - State Registration page I should see error: State NJ: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NJ
Then I should see the appropriate response depending on today's date for state: NJ
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NJ

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NM
Then in page Pesticide Details - State Registration page I should see error: State NM: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NM
Then in page Pesticide Details - State Registration page I should see error: State NM: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NM
Then I should see the appropriate response depending on today's date for state: NM
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NM

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NV
Then in page Pesticide Details - State Registration page I should see error: State NV: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NV
Then in page Pesticide Details - State Registration page I should see error: State NV: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NV
Then I should see the appropriate response depending on today's date for state: NV
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NV

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NY
Then in page Pesticide Details - State Registration page I should see error: State NY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NY
Then in page Pesticide Details - State Registration page I should see error: State NY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NY
Then I should see the appropriate response depending on today's date for state: NY
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NY

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: OH
Then in page Pesticide Details - State Registration page I should see error: State OH: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: OH
Then in page Pesticide Details - State Registration page I should see error: State OH: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: OH
Then I should see the appropriate response depending on today's date for state: OH
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: OH

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: OK
Then in page Pesticide Details - State Registration page I should see error: State OK: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: OK
Then in page Pesticide Details - State Registration page I should see error: State OK: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: OK
Then I should see the appropriate response depending on today's date for state: OK
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: OK

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: OR
Then in page Pesticide Details - State Registration page I should see error: State OR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: OR
Then in page Pesticide Details - State Registration page I should see error: State OR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: OR
Then I should see the appropriate response depending on today's date for state: OR
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: OR

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: PA
Then in page Pesticide Details - State Registration page I should see error: State PA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: PA
Then in page Pesticide Details - State Registration page I should see error: State PA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: PA
Then I should see the appropriate response depending on today's date for state: PA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: PA

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: PR
Then in page Pesticide Details - State Registration page I should see error: State PR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: PR
Then in page Pesticide Details - State Registration page I should see error: State PR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: PR
Then I should see the appropriate response depending on today's date for state: PR
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: PR

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: RI
Then in page Pesticide Details - State Registration page I should see error: State RI: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: RI
Then in page Pesticide Details - State Registration page I should see error: State RI: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: RI
Then I should see the appropriate response depending on today's date for state: RI
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: RI

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: SC
Then in page Pesticide Details - State Registration page I should see error: State SC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: SC
Then in page Pesticide Details - State Registration page I should see error: State SC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: SC
Then I should see the appropriate response depending on today's date for state: SC
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: SC

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: SD
Then in page Pesticide Details - State Registration page I should see error: State SD: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: SD
Then in page Pesticide Details - State Registration page I should see error: State SD: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: SD
Then I should see the appropriate response depending on today's date for state: SD
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: SD

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: TN
Then in page Pesticide Details - State Registration page I should see error: State TN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: TN
Then in page Pesticide Details - State Registration page I should see error: State TN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: TN
Then I should see the appropriate response depending on today's date for state: TN
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: TN

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: TX
Then in page Pesticide Details - State Registration page I should see error: State TX: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: TX
Then in page Pesticide Details - State Registration page I should see error: State TX: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: TX
Then I should see the appropriate response depending on today's date for state: TX
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: TX

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: UT
Then in page Pesticide Details - State Registration page I should see error: State UT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: UT
Then in page Pesticide Details - State Registration page I should see error: State UT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: UT
Then I should see the appropriate response depending on today's date for state: UT
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: UT

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: VA
Then in page Pesticide Details - State Registration page I should see error: State VA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: VA
Then in page Pesticide Details - State Registration page I should see error: State VA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: VA
Then I should see the appropriate response depending on today's date for state: VA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: VA

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: VT
Then in page Pesticide Details - State Registration page I should see error: State VT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: VT
Then in page Pesticide Details - State Registration page I should see error: State VT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: VT
Then I should see the appropriate response depending on today's date for state: VT
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: VT

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: WA
Then in page Pesticide Details - State Registration page I should see error: State WA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: WA
Then in page Pesticide Details - State Registration page I should see error: State WA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: WA
Then I should see the appropriate response depending on today's date for state: WA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: WA

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: WI
Then in page Pesticide Details - State Registration page I should see error: State WI: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: WI
Then in page Pesticide Details - State Registration page I should see error: State WI: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: WI
Then I should see the appropriate response depending on today's date for state: WI
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: WI

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: WV
Then in page Pesticide Details - State Registration page I should see error: State WV: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: WV
Then in page Pesticide Details - State Registration page I should see error: State WV: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: WV
Then I should see the appropriate response depending on today's date for state: WV
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: WV

Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: WY
Then in page Pesticide Details - State Registration page I should see error: State WY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: WY
Then in page Pesticide Details - State Registration page I should see error: State WY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: WY
Then I should see the appropriate response depending on today's date for state: WY
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: WY

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
