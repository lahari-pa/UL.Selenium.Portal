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
Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
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

# Assigned to Barrett, Beverly
Scenario: [56594] Pesticide Data - EPA Expiration date validation (Idaho - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
#And [Shared Step 31050 - Welcome page - Save and Next]
#And I In the shared step below use Bathroom and tile cleaner - non-aerosol as your product type
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bathroom and tile cleaner - non-aerosol
And I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: ID
Then in page Pesticide Details - State Registration Details I should see error: State ID: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: ID
Then in page Pesticide Details - State Registration Details I should see error: State ID: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: ID
Then I should see the appropriate response depending on today's date for state: ID
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: ID
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56594

# Assigned to Barrett, Beverly
Scenario: [56596] Pesticide Data - EPA Expiration date validation (Indiana - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: IN
Then in page Pesticide Details - State Registration Details I should see error: State IN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: IN
Then in page Pesticide Details - State Registration Details I should see error: State IN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: IN
Then I should see the appropriate response depending on today's date for state: IN
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: IN
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56596

# Assigned to Barrett, Beverly
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
Scenario: [56599] Pesticide Data - EPA Expiration date validation (Kentucky - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: KY
Then in page Pesticide Details - State Registration Details I should see error: State KY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: KY
Then in page Pesticide Details - State Registration Details I should see error: State KY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
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
Scenario: [56600] Pesticide Data - EPA Expiration date validation (Louisiana - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: LA
Then in page Pesticide Details - State Registration Details I should see error: State LA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: LA
Then in page Pesticide Details - State Registration Details I should see error: State LA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: LA
Then I should see the appropriate response depending on today's date for state: LA
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: LA
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56600

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
Scenario: [56601] Pesticide Data - EPA Expiration date validation (Louisiana - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MD
Then in page Pesticide Details - State Registration Details I should see error: State MD: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MD
Then in page Pesticide Details - State Registration Details I should see error: State MD: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
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
Scenario: [56602] Pesticide Data - EPA Expiration date validation (Louisiana - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: ME
Then in page Pesticide Details - State Registration Details I should see error: State ME: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: ME
Then in page Pesticide Details - State Registration Details I should see error: State ME: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: ME
Then I should see the appropriate response depending on today's date for state: ME
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: ME
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56602

# Assigned to Barrett, Beverly
Scenario: [56603] Pesticide Data - EPA Expiration date validation (Minnesota - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MN
Then in page Pesticide Details - State Registration Details I should see error: State MN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MN
Then in page Pesticide Details - State Registration Details I should see error: State MN: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MN
Then I should see the appropriate response depending on today's date for state: MN
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MN
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56603

# Assigned to Barrett, Beverly
Scenario: [56604] Pesticide Data - EPA Expiration date validation (Missouri -Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MO
Then in page Pesticide Details - State Registration Details I should see error: State MO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MO
Then in page Pesticide Details - State Registration Details I should see error: State MO: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MO
Then I should see the appropriate response depending on today's date for state: MO
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MO
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56604

# Assigned to Barrett, Beverly
Scenario: [56605] Pesticide Data - EPA Expiration date validation (Mississippi - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MS
Then in page Pesticide Details - State Registration Details I should see error: State MS: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MS
Then in page Pesticide Details - State Registration Details I should see error: State MS: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MS
Then I should see the appropriate response depending on today's date for state: MS
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MS
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56605

# Assigned to Barrett, Beverly
Scenario: [56606] Pesticide Data - EPA Expiration date validation (Montana - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: MT
Then in page Pesticide Details - State Registration Details I should see error: State MT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: MT
Then in page Pesticide Details - State Registration Details I should see error: State MT: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: MT
Then I should see the appropriate response depending on today's date for state: MT
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: MT
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56606

# Assigned to Barrett, Beverly
Scenario: [56607] Pesticide Data - EPA Expiration date validation (North Carloina - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NC
Then in page Pesticide Details - State Registration Details I should see error: State NC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NC
Then in page Pesticide Details - State Registration Details I should see error: State NC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NC
Then I should see the appropriate response depending on today's date for state: NC
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NC
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56607

# Assigned to Barrett, Beverly
Scenario: [56608] Pesticide Data - EPA Expiration date validation (Nebraska - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NC
Then in page Pesticide Details - State Registration Details I should see error: State NC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NC
Then in page Pesticide Details - State Registration Details I should see error: State NC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NC
Then I should see the appropriate response depending on today's date for state: NC
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NC
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56608

# Assigned to Barrett, Beverly
Scenario: [56609] Pesticide Data - EPA Expiration date validation (New Hampshire - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NH
Then in page Pesticide Details - State Registration Details I should see error: State NH: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NH
Then in page Pesticide Details - State Registration Details I should see error: State NH: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NH
Then I should see the appropriate response depending on today's date for state: NH
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NH
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56609

# Assigned to Barrett, Beverly
Scenario: [56610] Pesticide Data - EPA Expiration date validation (New Jersey - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NJ
Then in page Pesticide Details - State Registration Details I should see error: State NJ: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NJ
Then in page Pesticide Details - State Registration Details I should see error: State NJ: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NJ
Then I should see the appropriate response depending on today's date for state: NJ
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NJ
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56610

# Assigned to Barrett, Beverly
Scenario: [56611] Pesticide Data - EPA Expiration date validation (New Mexico - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NM
Then in page Pesticide Details - State Registration Details I should see error: State NM: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NM
Then in page Pesticide Details - State Registration Details I should see error: State NM: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NM
Then I should see the appropriate response depending on today's date for state: NM
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NM
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56611

# Assigned to Barrett, Beverly
Scenario: [56612] Pesticide Data - EPA Expiration date validation (Nevada - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: NV
Then in page Pesticide Details - State Registration Details I should see error: State NV: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: NV
Then in page Pesticide Details - State Registration Details I should see error: State NV: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: NV
Then I should see the appropriate response depending on today's date for state: NV
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: NV
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56612

# Assigned to Barrett, Beverly
Scenario: [56613] Pesticide Data - EPA Expiration date validation (Oregon - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: OR
Then in page Pesticide Details - State Registration Details I should see error: State OR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: OR
Then in page Pesticide Details - State Registration Details I should see error: State OR: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: OR
Then I should see the appropriate response depending on today's date for state: OR
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: OR
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56613

# Assigned to Barrett, Beverly
Scenario: [56614] Pesticide Data - EPA Expiration date validation (Pennsylvania - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: PA
Then in page Pesticide Details - State Registration Details I should see error: State PA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: PA
Then in page Pesticide Details - State Registration Details I should see error: State PA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: PA
Then I should see the appropriate response depending on today's date for state: PA
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: PA
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56614

# Assigned to Barrett, Beverly
Scenario: [56615] Pesticide Data - EPA Expiration date validation (Virginia - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: VA
Then in page Pesticide Details - State Registration Details I should see error: State VA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: VA
Then in page Pesticide Details - State Registration Details I should see error: State VA: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: VA
Then I should see the appropriate response depending on today's date for state: VA
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: VA
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56615

# Assigned to Barrett, Beverly
Scenario: [56616] Pesticide Data - EPA Expiration date validation (Wisconsin - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: WI
Then in page Pesticide Details - State Registration Details I should see error: State WI: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: WI
Then in page Pesticide Details - State Registration Details I should see error: State WI: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: WI
Then I should see the appropriate response depending on today's date for state: WI
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: WI
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56616

# Assigned to Barrett, Beverly
Scenario: [56617] Pesticide Data - EPA Expiration date validation (West Virginia - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: WV
Then in page Pesticide Details - State Registration Details I should see error: State WV: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: WV
Then in page Pesticide Details - State Registration Details I should see error: State WV: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: WV
Then I should see the appropriate response depending on today's date for state: WV
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: WV
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56617

# Assigned to Barrett, Beverly
Scenario: [56618] Pesticide Data - EPA Expiration date validation (Wyoming - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: WY
Then in page Pesticide Details - State Registration Details I should see error: State WY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: WY
Then in page Pesticide Details - State Registration Details I should see error: State WY: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: WY
Then I should see the appropriate response depending on today's date for state: WY
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: WY
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56618

# Assigned to Barrett, Beverly
Scenario: [56619] Pesticide Data - EPA Expiration date validation (Washington DC - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: DC
Then in page Pesticide Details - State Registration Details I should see error: State DC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: DC
Then in page Pesticide Details - State Registration Details I should see error: State DC: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: DC
Then I should see the appropriate response depending on today's date for state: DC
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: DC
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56619

# Assigned to Barrett, Beverly
Scenario: [56621] Pesticide Data - EPA Expiration date validation (South Dakota - June 30th no more than 2 years out)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55843 (EPA expiration date - enter current year - Not June 30th) for state: SD
Then in page Pesticide Details - State Registration Details I should see error: State SD: Valid date is June 30 no more than two calendar years out.
And I call Shared Step 55844 (EPA expiration date - enter next year - Not June 30th) for state: SD
Then in page Pesticide Details - State Registration Details I should see error: State SD: Valid date is June 30 no more than two calendar years out.
And I call Shared Step (EPA expiration date - enter current year plus 2 - Not June 30th) for state: SD
Then in page Pesticide Details - State Registration Details I should see error: State SD: Valid date is June 30 no more than two calendar years out.
And I call Shared Step 55845 (EPA expiration date - enter current year - June 30th) for state: SD
And I should see the Transportation Details 1 Page
And in the New Product page I click section: Pesticide Details - State Registration Details
And I call Shared Step 55846 (EPA expiration date - enter next year - June 30th) for state: SD
And I should see the Transportation Details 1 Page
And in the New Product page I click section: Pesticide Details - State Registration Details
And I call Shared Step (EPA expiration date - enter current year plus 2 - June 30th) for state: SD
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56621

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
Scenario: [56622] Pesticide Data - EPA Expiration date validation (Rhode Island - Nov 30th for current year, until Sept 1st, then Nov 30th of this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
#And I In the shared steps below select Pet Shampoo with Pest Control as your product type
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
#And I We will be working with RI (Rhode Island) for the next set of steps
And I call Shared Step 55858 (EPA expiration date - enter current year - NOT Nov 30th) for state: RI
Then in page Pesticide Details - State Registration Details I should see error: State RI: Valid dates are November 30 of current calendar year until September 1, at which time November 30 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55859 (EPA expiration date - enter next year - Nov 30th) for state: RI
#And I If the current date is after Sept 1st then Confirm that no error is shown for the States - if the current date is before Sept 1st then the error "SaveState RI: Valid dates are November 30 of current calendar year until September 1, at which time November 30 of either the current or the following calendar year would be acceptable" will be shown
And If the current date is after (MM/DD): 09/01 then I confirm no error is shown for the State: RI - else I confirm the following error is displayed: State RI: Valid dates are November 30 of current calendar year until September 1, at which time November 30 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55860 (Expiration date - enter this year - Nov 30th) for state: RI
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56622

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
Scenario: [56624] Pesticide Data - EPA Expiration date validation (Vermont - Nov 30th for current year, until Sept 1st, then Nov 30th of this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55858 (EPA expiration date - enter current year - NOT Nov 30th) for state: VT
Then in page Pesticide Details - State Registration Details I should see error: State VT: Valid dates are November 30 of current calendar year until September 1, at which time November 30 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55859 (EPA expiration date - enter next year - Nov 30th) for state: VT
And If the current date is after (MM/DD): 09/01 then I confirm no error is shown for the State: VT - else I confirm the following error is displayed: State VT: Valid dates are November 30 of current calendar year until September 1, at which time November 30 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55860 (Expiration date - enter this year - Nov 30th) for state: VT
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56624

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
Scenario: [56625] Pesticide Data - EPA Expiration date validation (South Carolina - Aug 31st until June 1st then Aug 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I select expiration date (current year - Not August 31st) for state: SC
And I click continue
Then in page Pesticide Details - State Registration Details I should see error: State SC: Valid dates are August 31 of current calendar year until June 1, at which time August 31 of either the current or the following calendar year would be acceptable.
And I select expiration date (next year - Not August 31st) for state: SC
And I click continue
Then in page Pesticide Details - State Registration Details I should see error: State SC: Valid dates are August 31 of current calendar year until June 1, at which time August 31 of either the current or the following calendar year would be acceptable.
And I enter the EPA registration date in the current year:
| State | Day | Month | Increment year? |
| SC    | 31  | 08    | no              |
And I click continue
And If the current date is after (MM/DD): 08/31 then I confirm the error is displayed: 'The expiration date must be a valid future date' - else I confirm that no error is shown and the 'Transportation Details 1' page has loaded
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56625


# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
Scenario: [56627] Pesticide Data - EPA Expiration date validation (North Dakota - December 31st no more than 2 years out but must be ODD number)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: ND
Then in page Pesticide Details - State Registration Details I should see error: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: ND
Then in page Pesticide Details - State Registration Details I should see error: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
And I select EPA expiration date - enter current year plus 2:
| State | Day | Month |
| ND    | 1   | 12    |
And I click continue
Then in page Pesticide Details - State Registration Details I should see error: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: ND
And If the current year is an even number - Confirm that an error shows: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
And If the current year is an odd number - Confirm that an error shows: NONE
And in the New Product page I click section: Pesticide Details - State Registration Details
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: ND
And If the next year is an even number - Confirm that an error shows: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
And If the next year is an odd number - Confirm that an error shows: NONE
And in the New Product page I click section: Pesticide Details - State Registration Details
And I select EPA expiration date - enter current year plus 2:
| State | Day | Month |
| ND    | 31   | 12    |
And I click continue
And If the current year is an even number - Confirm that an error shows: State ND: Valid dates are December 31 no more than two (2) calendar years out, but year must be ODD number (i.e., 2017, 2019).
And If the current year is an odd number I confirm that no error is displayed and the 'Transportation Details 1' page has loaded
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56627


# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
Scenario: [56629] Pesticide Data - EPA Expiration date validation (Florida - December 31st no more than 2 years out but must be EVEN number)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: FL
Then in page Pesticide Details - State Registration Details I should see error: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: FL
Then in page Pesticide Details - State Registration Details I should see error: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
And I select EPA expiration date - enter current year plus 2:
| State | Day | Month |
| FL    | 1   | 12    |
And I click continue
Then in page Pesticide Details - State Registration Details I should see error: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: FL
And If the current year is an odd number - Confirm that an error shows: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
And If the current year is an even number - Confirm that an error shows: NONE
And in the New Product page I click section: Pesticide Details - State Registration Details
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: FL
And If the next year is an odd number - Confirm that an error shows: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
And If the next year is an even number - Confirm that an error shows: NONE
And in the New Product page I click section: Pesticide Details - State Registration Details
And I select EPA expiration date - enter current year plus 2:
| State | Day | Month |
| FL    | 31   | 12    |
And I click continue
And If the current year is an odd number - Confirm that an error shows: State FL: Valid dates are December 31 no more than two (2) calendar years out, but year must be EVEN number (i.e., 2018, 2020).
And If the current year is an even number I confirm that no error is displayed and the 'Transportation Details 1' page has loaded
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56629

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides\EPA State Expiry Date Validation
Scenario: [56635] Pesticide Data - EPA Expiration date validation (Arizona - Dec 31st no more than 2 years out)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: AZ
Then in page Pesticide Details - State Registration Details I should see error: State AZ: Valid dates are December 31 no more than two (2) calendar years out.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: AZ
Then in page Pesticide Details - State Registration Details I should see error: State AZ: Valid dates are December 31 no more than two (2) calendar years out.
And I call Shared Step 55886 (EPA expiration date - enter current year plus 2 - NOT Dec 31st) for state: AZ
Then in page Pesticide Details - State Registration Details I should see error: State AZ: Valid dates are December 31 no more than two (2) calendar years out.
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: AZ
Then in page Pesticide Details - State Registration Details I should see no errors
And in the New Product page I click section: Pesticide Details - State Registration Details
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: AZ
Then in page Pesticide Details - State Registration Details I should see no errors
And in the New Product page I click section: Pesticide Details - State Registration Details
And I call Shared Step 55887 (EPA expiration date - enter current year plus 2 - Dec 31st) for state: AZ
Then in page Pesticide Details - State Registration Details I should see no errors
And in the New Product page I click section: Pesticide Details - State Registration Details
And I select EPA expiration date - enter current year plus 3:
| State | Day | Month |
| AZ    | 31   | 12    |
And I click continue
Then in page Pesticide Details - State Registration Details I should see error: State AZ: Valid dates are December 31 no more than two (2) calendar years out.
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56635
