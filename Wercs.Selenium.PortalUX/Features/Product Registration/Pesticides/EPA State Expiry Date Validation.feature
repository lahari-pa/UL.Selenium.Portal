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
@run_EPAState

Feature:  EPA State Expiry Date Validation (Suite ID: 56545)

Scenario: [56593] Pesticide Data - EPA Expiration date validation (Iowa - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wipes, Disinfecting
Given I save the product information as: TestCase56593
Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
#Given I call Shared Step 57502 (Additional Product Information - Pesticide & Child shown, US only, No to everything else - Continue - Happy Path)
Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: IA
Then in page Pesticide Details - State Registration Details I should see error: State IA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: IA
Then in page Pesticide Details - State Registration Details I should see error: State IA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: IA
Then I should see the appropriate response depending on today's date for state: IA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: IA
Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56593

Scenario: [56592] Pesticide Data - EPA Expiration date validation (Georgia - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wood Finishing Cloth with Stain
Given I save the product information as: TestCase56592
Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: GA
Then in page Pesticide Details - State Registration Details I should see error: State GA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: GA
Then in page Pesticide Details - State Registration Details I should see error: State GA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: GA
Then I should see the appropriate response depending on today's date for state: GA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: GA
Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56592

Scenario: [56582] Pesticide Data - EPA Expiration date validation (Alaska - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wood Finishing Cloth with Stain
Given I save the product information as: TestCase56582
Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
#Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: AK
Then in page Pesticide Details - State Registration Details I should see error: State AK: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: AK
Then in page Pesticide Details - State Registration Details I should see error: State AK: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: AK
Then I should see the appropriate response depending on today's date for state: AK
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: AK
Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56582

Scenario: [56591] Pesticide Data - EPA Expiration date validation (Colorado Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Flying Bug Insecticide - Non-aerosol
Given I save the product information as: TestCase56591
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: CO
Then in page Pesticide Details - State Registration Details I should see error: State CO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: CO
Then in page Pesticide Details - State Registration Details I should see error: State CO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: CO
Then I should see the appropriate response depending on today's date for state: CO
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: CO
Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56591

Scenario: [56590] Pesticide Data - EPA Expiration date validation (California - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crawling Bug - Aerosol
Given I save the product information as: TestCase56590
Given I call Shared Step 57528 (Product Characteristics - Aerosol Only - add data - Continue - Happy Path)
Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Butane
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: CA
Then in page Pesticide Details - State Registration Details I should see error: State CA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: CA
Then in page Pesticide Details - State Registration Details I should see error: State CA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: CA
Then I should see the appropriate response depending on today's date for state: CA
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: CA
Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56590

Scenario: [56583] Pesticide Data - EPA Expiration date validation (Arkansas > Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
Given I save the product information as: TestCase56583
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
#Given I call Shared Step 57502 (Additional Product Information - Pesticide & Child shown, US only, No to everything else - Continue - Happy Path)
Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
Given I call Shared Step 63226 (Pesticide Date - Yes registered - Enter EPA Number not on Kelly - Click Continue - Happy path)
Given I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: AR
Then in page Pesticide Details - State Registration Details I should see error: State AR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: AR
Then in page Pesticide Details - State Registration Details I should see error: State AR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
Given I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: AR
Then I should see the appropriate response depending on today's date for state: AR
Given I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: AR
Then I should see the Transportation Details 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56583
